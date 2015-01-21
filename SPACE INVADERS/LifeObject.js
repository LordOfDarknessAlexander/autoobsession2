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
		if(this.isDrawn = true)
		{
			context.drawImage(image, this.xPos, this.yPos);
		}
	},
	
	lifeClear : function(lifeToClear)
	{
		lifeObjects[lifeToClear].isDrawn = false;
	},
	
	lifeRemove : function()
	{
		for(var i = 0; i < lifeObjects.length; ++i)
		{
			if(lifeObjects[i].isDrawn)
			{
				setTimeout(function() { lifeClear(i); }, 1000);
				break;
			}
		}
	},
	
	lifeAdd : function()
	{
		for(var i = lifeObjects.length - 1; i >= 0; --i)
		{
			if(!lifeObjects[i].isDrawn)
			{
				lifeObjects[i].isDrawn = true;
			}
		}
	},
	
	resetLives : function()
	{
		for(var i = 0; i < lifeObjects.length; ++i)
		{
			lifeObjects[i].isDrawn = true;
		}
	}
};