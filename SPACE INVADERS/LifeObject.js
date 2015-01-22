var LifeObjectClass =
{
	xPos : 0,
	yPos : 0,
	width : 0,
	height : 0,
	isDrawn : true,		//true = is drawn on the canvas

	init : function(x, y)
	{
		this.xPos = x;
		this.yPos = y;
		this.width = 20;
		this.height = 20;
		this.isDrawn = true;
	},

	render : function(context, image)
	{
		if(this.isDrawn = true)
		{
			context.drawImage(image, this.xPos, this.yPos);
		}
	}
};