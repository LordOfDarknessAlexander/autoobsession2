var LifeObjectClass =
{
	xPos : 0,
	yPos : 0,
	width : 0,
	height : 0,
	xOffset : 0,
	isDrawn : true,		//true = is drawn on the canvas

	init : function(posX, posY)
	{
		this.xPos = posX;
		this.yPos = posY;
		this.width = 20;
		this.height = 20;
		this.xOffset = this.width + 5;
	},
	
	render : function(context, image)
	{
		context.drawImage(image, this.xPos, this.yPos)
	},
	
	update : function()
	{
		console.log("Pos: " + this.xPos + ", " + this.yPos);
	}
};