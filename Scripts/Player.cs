using Godot;

public partial class Player : CharacterBody2D
{
	#region Public Vars
	[Export]
	public int baseHealth = 10;
	[Export]
	public int baseDamage = 1;
	[Export]
	public int baseSpeed = 300;
	#endregion

	#region Private Vars
	private int health;
	private int damage;
	private int speed;
	private Vector2 inputVector = Vector2.Zero;
	#endregion

	#region Public Methods
	public override void _Ready()
	{
		SetupAttributes();
	}

	public override void _PhysicsProcess(double delta)
	{
		MovementHandler(delta);
		SprintHandler();
		Settings.UpdateSettingsUI(this);

		if (Input.IsKeyPressed(Key.Escape))
		{
			Settings.QuitGame(this);
		}
	}
	#endregion

	#region Private Methods
	private void MovementHandler(double delta)
	{
		inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		Velocity = inputVector.Normalized() * speed;
		MoveAndSlide();
	}

	private void SprintHandler()
	{
		/*
		if (Input.IsActionPressed("sprint"))
		{
			speed = baseSpeed * 2;
		}
		else
		{
			speed = baseSpeed;
		}
		*/
	}

	private void SetupAttributes()
	{
		health = baseHealth;
		damage = baseDamage;
		speed = baseSpeed;
	}
	#endregion

	#region Error Handling
	#endregion
}
