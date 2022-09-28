using Godot;
using System;

[Tool]
public partial class Circle : Polygon2D
{
	[Export]
	public int PointCount {
		get => _pointCount;
		set {
			_pointCount = value;
			Redraw();
		}
	}
	private int _pointCount = 100;

	[Export]
	public float Radius {
		get => _radius;
		set {
			_radius = value;
			Redraw();
			ResizeTexture();
		}
	}

	private float _radius = 10;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Redraw();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Redraw() 
	{
		GD.Print("Redrawing...");
		var polygon = new Vector2[PointCount];
		for (int i = 0; i < PointCount; i++)
		{
			float angle =  Mathf.DegToRad(360.0f / PointCount * i);

			Vector2 location = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));

			location *= Radius;

			polygon[i] = location;
		}
		this.Polygon = polygon;
	}

	private void ResizeTexture() 
	{
		if (Texture is not null)
		{
			this.TextureScale = Texture.GetSize() / (Radius * 2);
			this.TextureOffset = new Vector2(Radius, Radius);
		}
	}
}
