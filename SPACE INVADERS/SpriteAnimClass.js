var SpriteAnimClass = 
{
	image : undefined,
	rect : undefined,
	srcX : 0,
	srcY : 0,
	frameWidth : 0,
	frameHeight : 0,
	framesWide : 0,
	framesHigh : 0,
	imageWidth : 0,
	imageHeight : 0,
	startFrame : 0,
	currFrame : 0,
	numFrames : 6,
	frameRate : 64, //number of milliseconds between frames
	loop : true,
	isPlaying : false,
	visible : true,
	alpha : 1,
	timer : undefined,

	updateFrameCoords: function()
	{
		this.srcX = ((this.startFrame + this.currentFrame) % this.framesWide) * this.frameWidth;
		this.srcY = Math.floor((this.startFrame + this.currentFrame) / this.framesWide) * this.frameHeight;
	},
	
	init : function(image, x, y, frameWidth, frameHeight, startFrame, numFrames, frameRate)
	{
		this.image = image;
		this.frameWidth = frameWidth;
		this.frameHeight = frameHeight;
		this.framesWide = Math.floor(image.width / frameWidth);
		this.framesHight = Math.floor(image.height / frameHeight);
		this.imageWidth = image.width;
		this.imageHeight = image.height;
		this.startFrame = startFrame;
		this.numFrames = numFrames;
		this.frameRate = frameRate;
		this.halfWidth = Math.ceil(frameWidth / 2);
		this.halfHeight = Math.ceil(frameHeight / 2);
		this.updateFrameCoords();
		this.rect = Object.create(RectClass);
		this.rect.init(x, y, frameWidth, frameHeight, 0);
	},
	
	play : function(loop)
	{
		this.isPlaying = true;
		this.loop = loop;
		var self = this;
		this.timer = setTimeout(function() { self.updateAnimation(); }, this.frameRate);
	},
	
	stop : function(reset)
	{
		if(this.isPlaying)
		{
			this.isPlaying = false;
			if(reset)
			{
				this.currFrame = 0;
				this.updateFrameCoords();
			}
			clearTimeout(this.timer);
		}
	},
	
	restart : function()
	{
		clearTimeout(this.timer);
		this.currFrame = 0;
		this.updateFrameCoords();
		this.play(true);
	},
	
	updateAnimation : function()
	{
		this.currFrame++;
		if(this.currFrame >= this.numFrames)
		{
			if(this.loop)
			{
				this.currFrame = 0;
			}
			else
			{
				this.isPlaying = false;
				this.currFrame--;
			}
		}
		
		this.updateFrameCoords();
		if(this.isPlaying)
		{
			var self = this;
			this.timer = setTimeout(function () { self.updateAnimation(); }, this.frameRate);
		}
	},
	
	render : function(context)
	{
		if(this.visible)
		{
			context.save();
			context.translate(this.rect.x + this.rect.halfWidth, this.rect.y + this.rect.halfHeight);
			context.rotate(this.rect.angle);
			context.globalAlpha = this.alpha;
			context.drawImage(this.image, this.srcX, this.srcY, this.frameWidth, this.frameHeight,
								-this.rect.halfWidth, -this.rect.halfHeight, this.rect.width, this.rect.height);
			context.restore();
		}
	}
};