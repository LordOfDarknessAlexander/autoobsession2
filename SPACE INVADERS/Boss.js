var Boss = 
{
	x : 0,
	y : 0,
	vX : 0,
	vY : 0,
	width : 0,
	height : 0,
	numLives : 0,
	isDrawn : false,
	
	init : function(x, y, vx, vy)
	{
		this.x = x;
		this.y = y;
		this.vX = vx;
		this.vY = vy;
		this.width = 90;
		this.height = 41;
		this.numLives = 3;
	},
	
	update : function()	
	{	
		this.x += this.vX;
		this.y += this.vY;
	},
	
	render : function(context, image)
	{
		if(this.isDrawn)
		{
			context.drawImage(image, this.x, this.y);
		}
	},
	
	drawBoss : function()
	{
		this.isDrawn = true;
	},
	
	die : function()
	{
		this.isDrawn = false;
	}
};