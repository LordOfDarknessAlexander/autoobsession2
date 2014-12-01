var Background =
{
	x: 0,
	y: 0,
	vY: 0,
	
	create: function(x, y, vY)
	{
		this.x = x;
		this.y = y;
		this.vY = vY;
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
