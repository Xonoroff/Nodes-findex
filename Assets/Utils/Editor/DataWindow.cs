using System;
using Entities;
using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
    public class DataWindow : EditorWindow
    {
        public Vector2 scrollPosition = Vector2.zero;
    
        private ContainerWrapper Container;

        private float itemHeight = 100;

        private float itemsPadding = 10;
    
        [MenuItem ("Window/Data Window")]
        public static void  ShowWindow ()
        {
            GetWindow(typeof(DataWindow));
        }

    
        void OnGUI ()
        {
            if (Container != null)
            {
                int visibleItems = (int) (position.height / (itemHeight + itemsPadding));
                int currentIndex = Convert.ToInt32(scrollPosition.y / (itemHeight + itemsPadding));

                var scrollHeight = (currentIndex + visibleItems) * itemHeight +
                                   (currentIndex + visibleItems) * itemsPadding + itemHeight;
                scrollPosition = GUI.BeginScrollView(new Rect(0, 0, position.width, position.height - 100),
                    scrollPosition, new Rect(0, 0, position.width, scrollHeight), new GUIStyle(), new GUIStyle());

                for (int i = 0; i <= visibleItems; i++)
                {
                    int expectedIndex = currentIndex + i;
                    FillItem(Container[expectedIndex % Container.Count], expectedIndex);
                }

                //TODO: We can create fake items to improve UX.

                GUI.EndScrollView();
            }

            if (GUI.Button(new Rect(0,position.height - 100, position.width, position.height), "Create new data"))
            {
                CreateNewConianer();
            }
        }

        private void FillItem(NodeWrapper content, int index)
        {
            var prevColor = GUI.color;
            GUI.color = content.Value ? Color.green : Color.red;
            GUI.Button(new Rect(0, index * itemHeight + index * itemsPadding, position.width, itemHeight), content.Value.ToString());
            GUI.color = prevColor;
        }
    
        private void CreateNewConianer()
        {
            Container = new ContainerWrapper(100);
        }
    }
}
