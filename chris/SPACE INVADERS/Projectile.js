var Projectile =	// this will be the bullet class *** UNTESTED! ***
	{
		x: 0,
		y:0, 
		vX: 0,
		vY: 0,
		width: 0,
		height: 0,
		Bullet: undefined,	// the currently active animation
		lifeSpan: undefined,
		
		create: function(x, y, vY)	// initializes a new bullet object
		{
			this.x = x;
			this.y = y;
			this.vY = vY;
			this.width = 32;
			this.height = 32;
		},
		
		update: function()	// update function to update the bullet position on the screen *** UNTESTED! ***
		{
			this.y += this.vY;
		},
		
		render: function(context, image)
		{
			context.drawImage(image, this.x, this.y);
		},
	};