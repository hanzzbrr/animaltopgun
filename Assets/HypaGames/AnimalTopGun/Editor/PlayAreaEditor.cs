using UnityEngine;
using UnityEditor;

namespace HypaGames.AnimalTopGun
{
    [CustomEditor(typeof(PlayArea))]
    public class PlayAreaEditor : Editor
    {
        Color faceColor = new Color(0.5f, 1.0f, 0.5f, 0.15f);
        Color outLineColor = new Color(255, 255, 255, 1);

        void OnSceneGUI()
        {
            PlayArea playArea = target as PlayArea;
            DrawRectangle(playArea);
        }

        private void DrawRectangle(PlayArea playArea)
        {
            Vector3 pos = playArea.transform.position;

            Vector3[] verts = new Vector3[]
            {
                new Vector3(pos.x - playArea.Width, pos.y, pos.z - playArea.Length),
                new Vector3(pos.x - playArea.Width, pos.y, pos.z + playArea.Length),
                new Vector3(pos.x + playArea.Width, pos.y, pos.z + playArea.Length),
                new Vector3(pos.x + playArea.Width, pos.y, pos.z - playArea.Length)
            };

            Handles.DrawSolidRectangleWithOutline(verts, faceColor, outLineColor);
        }
    }
}
