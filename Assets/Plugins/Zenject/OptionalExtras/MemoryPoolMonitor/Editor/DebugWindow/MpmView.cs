using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;
using UnityEditor;
using UnityEngine.Profiling;
using Zenject;

namespace Zenject.MemoryPoolMonitor
{
    public class MpmView : IGuiRenderable, ITickable, IInitializable
    {
        readonly Settings _settings;
        readonly MpmWindow _window;

        readonly List<IMemoryPool> _pools = new List<IMemoryPool>();

        const int NumColumns = 6;

        static string[] ColumnTitles = new string[]
        {
            "Pool Type", "Num Total", "Num Active", "Num Inactive", "", ""
        };

        int _controlID;
        int _sortColumn = 0;
        float _scrollPosition;
        bool _poolListDirty;
        bool _sortDescending;
        Texture2D _rowBackground1;
        Texture2D _rowBackground2;
        Texture2D _rowBackgroundHighlighted;
        Texture2D _lineTexture;

        public MpmView(
            MpmWindow window,
            Settings settings)
        {
            _settings = settings;
            _window = window;
        }

        public float TotalWidth
        {
            get { return _window.position.width; }
        }

        string GetName(IMemoryPool pool)
        {
            var type = pool.GetType();
            return "{0}.{1}".Fmt(type.Namespace, type.PrettyName());
        }

        Texture2D CreateColorTexture(Color color)
        {
            var texture = new Texture2D(1, 1);
            texture.SetPixel(1, 1, color);
            texture.Apply();
            return texture;
        }

        public void Initialize()
        {
            StaticMemoryPoolRegistry.PoolAdded += OnPoolListChanged;
            StaticMemoryPoolRegistry.PoolRemoved += OnPoolListChanged;
            _poolListDirty = true;

            _rowBackground1 = CreateColorTexture(_settings.RowBackground1);
            _rowBackground2 = CreateColorTexture(_settings.RowBackground2);
            _rowBackgroundHighlighted = CreateColorTexture(_settings.RowBackgroundHighlighted);
            _lineTexture = CreateColorTexture(_settings.LineColor);
        }

        void OnPoolListChanged(IMemoryPool pool)
        {
            _poolListDirty = true;
        }

        public void Tick()
        {
            if (_poolListDirty)
            {
                _poolListDirty = false;
                _pools.Clear();
                _pools.AddRange(StaticMemoryPoolRegistry.Pools);
            }

            InPlaceStableSort<IMemoryPool>.Sort(_pools, ComparePools);
        }

        public void GuiRender()
        {
            _controlID = GUIUtility.GetControlID(FocusType.Passive);

            Rect windowBounds = new Rect(0, 0, TotalWidth, _window.position.height);

            Vector2 scrollbarSize = new Vector2(
                GUI.skin.horizontalScrollbar.CalcSize(GUIContent.none).y,
                GUI.skin.verticalScrollbar.CalcSize(GUIContent.none).x);

            Rect contentRect = new Rect(
                0, 0, windowBounds.width, _settings.HeaderHeight + _pools.Count() * _settings.RowHeight);
            Rect viewArea = windowBounds;

            viewArea.width -= scrollbarSize.y;

            Rect vScrRect = new Rect(windowBounds.x + viewArea.width, windowBounds.y, scrollbarSize.y, viewArea.height);
            _scrollPosition = GUI.VerticalScrollbar(vScrRect, _scrollPosition, viewArea.height, 0, contentRect.height);

            GUI.BeginGroup(viewArea);
            {
                contentRect.y = -_scrollPosition;

                GUI.BeginGroup(contentRect);
                {
                    DrawContent(contentRect.width);
                }
                GUI.EndGroup();
            }
            GUI.EndGroup();

            HandleEvents();
        }

        void HandleEvents()
        {
            switch (Event.current.GetTypeForControl(_controlID))
            {
                case EventType.ScrollWheel:
                {
                    _scrollPosition += Event.current.delta.y * _settings.ScrollSpeed;
                    break;
                }
            }
        }

        void DrawRowBackgrounds()
        {
            var mousePositionInContent = Event.current.mousePosition + Vector2.up * _scrollPosition;

            for (int i = 0; i < _pools.Count + 1; i++)
            {
                var rowRect = new Rect(
                    0, _settings.HeaderHeight + i * _settings.RowHeight,
                    TotalWidth, _settings.RowHeight);

                Texture2D background;

                if (rowRect.Contains(mousePositionInContent))
                {
                    background = _rowBackgroundHighlighted;
                }
                else if (i % 2 == 0)
                {
                    background = _rowBackground1;
                }
                else
                {
                    background = _rowBackground2;
                }

                GUI.DrawTexture(rowRect, background);
            }
        }

        float GetColumnWidth(int index)
        {
            if (index == 0)
            {
                return TotalWidth - (NumColumns - 1) * _settings.NormalColumnWidth;
            }

            return _settings.NormalColumnWidth;
        }

        void DrawContent(float width)
        {
            GUI.DrawTexture(new Rect(
                0, _settings.HeaderHeight - 0.5f * _settings.SplitterWidth, TotalWidth, _settings.SplitterWidth), _lineTexture);

            DrawRowBackgrounds();

            var columnPos = 0.0f;

            for (int i = 0; i < NumColumns; i++)
            {
                var columnWidth = GetColumnWidth(i);
                DrawColumn(i, columnPos, columnWidth);
                columnPos += columnWidth;
            }
        }

        void DrawColumn(
            int index, float position, float width)
        {
            var title = ColumnTitles[index];

            var columnHeight = _settings.HeaderHeight + _pools.Count() * _settings.RowHeight;

            if (index < 4)
            {
                GUI.DrawTexture(new Rect(
                    position + width - _settings.SplitterWidth * 0.5f, 0,
                    _settings.SplitterWidth, columnHeight), _lineTexture);
            }

            var columnBounds = new Rect(
                position + 0.5f * _settings.SplitterWidth, 0, width - _settings.SplitterWidth, columnHeight);

            GUI.BeginGroup(columnBounds);
            {
                var headerBounds = new Rect(0, 0, columnBounds.width, _settings.HeaderHeight);

                DrawColumnHeader(index, headerBounds, title);

                for (int i = 0; i < _pools.Count; i++)
                {
                    var pool = _pools[i];

                    var cellBounds = new Rect(
                        0, _settings.HeaderHeight + _settings.RowHeight * i,
                        columnBounds.width, _settings.RowHeight);

                    DrawColumnContents(index, cellBounds, pool);
                }
            }
            GUI.EndGroup();
        }

        void DrawColumnContents(
            int index, Rect bounds, IMemoryPool pool)
        {
            switch (index)
            {
                case 0:
                {
                    GUI.Label(bounds, GetName(pool), _settings.ContentNameTextStyle);
                    break;
                }
                case 1:
                {
                    GUI.Label(bounds, pool.NumTotal.ToString(), _settings.ContentNumberTextStyle);
                    break;
                }
                case 2:
                {
                    GUI.Label(bounds, pool.NumActive.ToString(), _settings.ContentNumberTextStyle);
                    break;
                }
                case 3:
                {
                    GUI.Label(bounds, pool.NumInactive.ToString(), _settings.ContentNumberTextStyle);
                    break;
                }
                case 4:
                {
                    var buttonBounds = new Rect(
                        bounds.x + _settings.ButtonMargin, bounds.y, bounds.width - _settings.ButtonMargin, bounds.height);

                    if (GUI.Button(buttonBounds, "Clear"))
                    {
                        pool.Clear();
                    }
                    break;
                }
                case 5:
                {
                    var buttonBounds = new Rect(
                        bounds.x, bounds.y, bounds.width - 15.0f, bounds.height);

                    if (GUI.Button(buttonBounds, "Expand"))
                    {
                        pool.ExpandPoolBy(5);
                    }
                    break;
                }
                default:
                {
                    throw Assert.CreateException();
                }
            }
        }

        void DrawColumnHeader(int index, Rect bounds, string text)
        {
            if (index > 3)
            {
                return;
            }

            if (_sortColumn == index)
            {
                var offset = _settings.TriangleOffset;
                var image = _sortDescending ? _settings.TriangleDown : _settings.TriangleUp;

                GUI.DrawTexture(new Rect(bounds.x + offset.x, bounds.y + offset.y, image.width, image.height), image);
            }

            if (GUI.Button(bounds, text, index == 0 ? _settings.HeaderTextStyleName : _settings.HeaderTextStyle))
            {
                if (_sortColumn == index)
                {
                    _sortDescending = !_sortDescending;
                }
                else
                {
                    _sortColumn = index;
                }
            }
        }

        int ComparePools(IMemoryPool left, IMemoryPool right)
        {
            if (_sortDescending)
            {
                var temp = right;
                right = left;
                left = temp;
            }

            switch (_sortColumn)
            {
                case 4:
                case 5:
                case 0:
                {
                    return GetName(left).CompareTo(GetName(right));
                }
                case 1:
                {
                    return left.NumTotal.CompareTo(right.NumTotal);
                }
                case 2:
                {
                    return left.NumActive.CompareTo(right.NumActive);
                }
                case 3:
                {
                    return left.NumInactive.CompareTo(right.NumInactive);
                }
            }

            throw Assert.CreateException();
        }

        [Serializable]
        public class Settings
        {
            public Texture2D TriangleUp;
            public Texture2D TriangleDown;
            public Vector2 TriangleOffset;

            public GUIStyle HeaderTextStyleName;
            public GUIStyle HeaderTextStyle;
            public GUIStyle ContentNumberTextStyle;
            public GUIStyle ContentNameTextStyle;

            public Color RowBackground1;
            public Color RowBackground2;
            public Color RowBackgroundHighlighted;
            public Color LineColor;

            public float ScrollSpeed = 1.5f;
            public float NormalColumnWidth;
            public float HeaderHeight;

            public float SplitterWidth;
            public float RowHeight;

            public float ButtonMargin = 3;
        }
    }
}
