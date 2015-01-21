var Boss = 
{
	xPos : 0,
	yPos : 0,
	xVel : 0,
	yVel : 0,
	isDrawn : false,
	//width : 0,
	//height : 0,
	
	init : function(x, y, vx, vy)
	{
		this.xPos = x;
		this.yPos = y;
		this.xVel = vx;
		this.yVel = vy;
		//this.width = 41;
		//this.height = 90;
	},
	
	update : function()	
	{	
		this.xPos += this.xVel;
		this.yPos += this.yVel;
	},
	
	render : function(context, image)
	{
		if(isDrawn)
		{
			context.drawImage(image, this.xPos, this.yPos);
		}
	},
	
	drawBoss : function()
	{
		isDrawn = true;
	}
};