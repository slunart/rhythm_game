-----------------------------------------------------------------------------------------
--
-- view1.lua
--
-----------------------------------------------------------------------------------------

local composer = require( "composer" )
local scene = composer.newScene()
local disco = require( "disco" )

local myText = nil
local myTick = nil
local player = nil
local bpm = 60 -- precisa ser multiplo de 20
local mspb, f = math.modf( 6000/bpm )
mspb = mspb * 10
local totalTime = 0
local tick = 0
print("mspb "..mspb )

local function refreshtime( t )

	local floor = math.floor

	local ms = floor( t % 1000)
	local hundredths = floor(ms / 10)
	local seconds = floor( t / 1000)
	local minutes = floor(seconds / 60);   seconds = floor(seconds % 60)
	formattedTime = string.format("%02d min %02d sec %02d ms", minutes, seconds, hundredths)

	return formattedTime
end

local function atualizaRelogio( evento )
	-- 1000 (1 segundo) /60 (60 frames por segundos) = 16,666667 (o tempo nao pode ser menor que isso, porque o performdelay está preso a taxa de frame/seg)
	totalTime = totalTime + 20
	myText.text = "Time: "..refreshtime( totalTime )

	if totalTime % mspb == 0 then

		if tick == 4 then
			tick = 0
		end

		tick = tick + 1
		disco.eventoMovimentoSeletor()
		--print(tick)
		audio.play( som_tick )
		myTick.text = tick		
	end

	-- diferença de 250 ms
	if totalTime % mspb <=  mspb/2 and tick == 4 then
        player[1]:setFillColor(0, 1, 0)	-- pinta de verde
    -- elseif totalTime % mspb > mspb/2 and totalTime % mspb <=  mspb - 1 and tick == 4 then
    --     player[1]:setFillColor(1, 1, 0) -- pinta de amarelo
    else
       player[1]:setFillColor(0, 0, 0, 0.1)	 -- pinta de cinza
	end
end

function scene:create( event )
	
	local sceneGroup = self.view

	-- fundo de tela branco
	local background = display.newRect( display.contentCenterX, display.contentCenterY, display.contentWidth, display.contentHeight )
	background:setFillColor( 1 )	-- white

	-- carregar os sons na memoria
	local backgroundMusic = audio.loadStream("musica60.mp3")
	totalTime = audio.getDuration( backgroundMusic )
	local som_tick = audio.loadSound("clock.ogg")

	local myMusica = display.newText( "Slow Blues 60 BPM Drum", display.contentCenterX, 10, native.systemFont, 16 )
	myMusica:setFillColor( 1, 0, 0 )	
	local myBpm = display.newText( "Bpm: "..bpm, display.contentCenterX, 30, native.systemFont, 16 )
	myBpm:setFillColor( 1, 0, 0 )
	myText = display.newText( "Time: ", display.contentCenterX, 50, native.systemFont, 16 )
	myText:setFillColor( 1, 0, 0 )
	player = disco.criar(display.contentCenterX,display.contentCenterY,1)
	myTick = display.newText( "", player[1].x, player[1].y, native.systemFont, 16 )
	myTick:setFillColor( 0, 0, 0 )

	local mspb, f = math.modf( 6000/bpm )
	mspb = mspb * 10
	totalTime = 0
	local tick = 0
	print("mspb "..mspb )

	timer.performWithDelay(20, atualizaRelogio, 0)
	audio.play( backgroundMusic )

	local function myTouchListener( event )
	 
	    if ( event.phase == "began" ) then
	        -- Code executed when the button is touched
	        print( "object touched = " .. tostring(event.target) )  -- "event.target" is the touched object
	        player[1]:setFillColor(1, 0, 0)
	    elseif ( event.phase == "moved" ) then
	        -- Code executed when the touch is moved over the object
	        print( "touch location in content coordinates = " .. event.x .. "," .. event.y )
	    elseif ( event.phase == "ended" ) then
	        -- Code executed when the touch lifts off the object
	        print( "touch ended on object " .. tostring(event.target) )
	        player[1]:setFillColor(0, 0, 0, 0.1)	        
	    end
	    return true  -- Prevents tap/touch propagation to underlying objects
	end		
	player:addEventListener( "touch", myTouchListener )

	audio.setVolume( 0.5 )

	-- all objects must be added to group (e.g. self.view)
	sceneGroup:insert( background )
end

function scene:show( event )
	local sceneGroup = self.view
	local phase = event.phase
	
	if phase == "will" then
		-- Called when the scene is still off screen and is about to move on screen
	elseif phase == "did" then
		-- Called when the scene is now on screen
		-- 
		-- INSERT code here to make the scene come alive
		-- e.g. start timers, begin animation, play audio, etc.
	end	
end

function scene:hide( event )
	local sceneGroup = self.view
	local phase = event.phase
	
	if event.phase == "will" then
		-- Called when the scene is on screen and is about to move off screen
		--
		-- INSERT code here to pause the scene
		-- e.g. stop timers, stop animation, unload sounds, etc.)
	elseif phase == "did" then
		-- Called when the scene is now off screen
	end
end

function scene:destroy( event )
	local sceneGroup = self.view
	
	-- Called prior to the removal of scene's "view" (sceneGroup)
	-- 
	-- INSERT code here to cleanup the scene
	-- e.g. remove display objects, remove touch listeners, save state, etc.
end

---------------------------------------------------------------------------------

-- Listener setup
scene:addEventListener( "create", scene )
scene:addEventListener( "show", scene )
scene:addEventListener( "hide", scene )
scene:addEventListener( "destroy", scene )

-----------------------------------------------------------------------------------------

return scene