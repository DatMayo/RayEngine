using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;


namespace RayEngine.Components;

public class Cube
{
        readonly Vector3 _position;
        
        readonly Vector3 _scale;

        /// <summary>
        /// Creates a new cube with the given parameters  
        /// </summary>
        /// <param name="Position">World Position</param>
        /// <param name="Scale">Size of the cube</param>
        /// <param name="Color">Color of the cube</param>
        public Cube(Vector3 Position, Vector3 Scale, Color Color) : this(Position, Scale, Color, false) {}

        /// <summary>
        /// Creates a new cube with the given parameters  
        /// </summary>
        /// <param name="Position">World Position</param>
        /// <param name="Scale">Size of the cube</param>
        /// <param name="Color">Color of the cube</param>
        /// <param name="Outlined">Draw cube outlines</param>
        public Cube(Vector3 Position, Vector3 Scale, Color Color, bool Outlined)
        {
                _position = Position;
                _scale = new Vector3(Scale.X, Scale.Y, Scale.Z);
                DrawCube(Position, _scale.X, _scale.Y, _scale.Z, Color);
                if(Outlined) DrawCubeWires(_position, _scale.X, _scale.Y, _scale.Z, BLACK);

        }
}