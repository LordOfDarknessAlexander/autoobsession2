var Boss = 
{
	x : 0,
	y : 0,
	vX : 0,
	vY : 0,
	isDrawn : false,
	width : 0,
	height : 0,
	
	init : function(x, y, vx, vy)
	{
		this.x = x;
		this.y = y;
		this.vX = vx;
		this.vY = vy;
		this.width = 90;
		this.height = 41;
	},
	
	update : function()	
	{	
		this.x += this.vX;
		this.y += this.vY;
	},
	
	render : function(context, image)
	{
		if(isDrawn)
		{
			context.drawImage(image, this.x, this.y);
		}
	},
	
	drawBoss : function()
	{
		isDrawn = true;
	}
};