var Player =
{
	x: 0,
	y: 0,
	vX: 0,
	vY: 0,
	width: 0,
	height: 0,
	numLives: 0,
	Player: undefined,
	isControlable: undefined,
	create: function(x, y, vX, vY, player)
	{
		this.x = x;
		this.y = y;
		this.vX = vX;
		this.vY = vY;
		this.Player = player;
		this.width = 84;
		this.height = 150;
		this.numLives = 3;
		isControlable = true;
	},
	
	update: function()
	{
		this.x += this.vX;
		this.y += this.vY;
	},
	
	render: function(context, image)
	{
		context.drawImage(image, this.x, this.y);
	},
};
