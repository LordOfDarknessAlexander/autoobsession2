var Enemy =
	{
		x: 0,
		y: 0,
		vX: 0,
		vY: 0,
		width: 0,
		height: 0,
		
		create: function(x, y, vX, vY)	
		{
			this.x = x;
			this.y = y;
			this.vX = vX;
			this.vY = vY;
			this.width = 41;
			this.height = 90;
		},
		
		update: function()	
		{	
			this.x += this.vX;
			this.y += this.vY;
		},
		render: function(context , image)
		{
			context.drawImage(image, this.x, this.y);
		},
	};