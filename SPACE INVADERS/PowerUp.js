var PowerUp =
{
	x: 0,
	y:0, 
	vX: 0,
	vY: 0,
	width: 0,
	height: 0,
	Bullet: undefined,
	lifeSpan: undefined,
	
	create: function(x, y, vY)	
	{
		this.x = x;
		this.y = y;
		this.vY = vY;
		this.width = 32;
		this.height = 32;
	},
	
	update: function()		
	{
		this.y += this.vY;
	},
	
	render: function(context, image)
	{
		context.drawImage(image, this.x, this.y);
	},
};
