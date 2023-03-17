using System.Numerics;
using RayEngine.Extensions;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace RayEngine.Components;

public class GameModel
{
    private Vector3 _position;
    private float _yaw = 0;
    private Model _model;
    private readonly float _scale;
    private float _speed;
    private readonly bool _outline;

    /// <summary>
    /// Creates a new game model
    /// </summary>
    /// <param name="modelUri">Path to model</param>
    public GameModel(string modelUri) : this(modelUri, 1f, false) {}
    
    /// <summary>
    /// Creates a new game model
    /// </summary>
    /// <param name="modelUri">Path to model</param>
    /// <param name="scale">Scale of the model</param>
    public GameModel(string modelUri, float scale) : this(modelUri, scale,  false) {}
    
    /// <summary>
    /// Creates a new game model
    /// </summary>
    /// <param name="modelUri">Path to model</param>
    /// <param name="scale">Scale of the model</param>
    /// <param name="outline">Draw an outline</param>
    public GameModel(string modelUri, float scale, bool outline)
    {
        _model = LoadModel(Engine.ResourceUrl.LocalPath + "/Models/" + modelUri);
        _scale = scale;
        _outline = outline;
    }

    public void Draw()
    {
        DrawModel(_model, _position, _scale, WHITE);
        if (!_outline) return;

        DrawModelWires(_model, _position, _scale, BLACK);
    }

    /// <summary>
    /// Gets the model of the current instance
    /// </summary>
    /// <returns>Current model</returns>
    public Model GetModel()
    {
        return _model;
    }

    public void Rotate(float degree)
    {
        _yaw += degree;
        _model.transform = Matrix4x4.CreateRotationY(Engine.Deg2Rad * _yaw);
    }

    public void MoveForward()
    {
        _position += Vector3.Zero.Forward();
    }

    public void MoveBackwards()
    {
        _position += Vector3.Zero.Backwards();
    }
}