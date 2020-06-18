# Three state machine example ... bad code included.

# variables
tired = 0
enemy_spotted = 0
enemy_strong = 0
enemy_weak = 0


states = ['idle','attacking','defending',]
current_state = 'idle'

alive = True
running = True
max_limit = 100
game_time = 0

while running and alive:
    game_time += 1

    # idle:  checks for enemies and tiredness reduces
    if current_state is 'idle':
        # Do things for this state
        print("hm..I'm bored, I want to sleep")
        tired -= 1
        enemy_spotted += 1
        # Check for change state
        if tired < 5:
            current_state = 'attacking'
        if enemy_spotted > 3:
            current_state = 'defending'

    # attacking: gets tired, has to defend
    elif current_state is 'attacking':
        # Do things for this state
        print("too weak, I'm going to beat you Ah! ...")
        tired += 1
        enemy_strong += 1
        # Check for change state
        if tired > 5:
            current_state = 'idle'
        if enemy_strong > 5:
            current_state = 'defending'
            
    # defending: saving stamina. regains strength, kills weak enemy and patrol for more
    elif current_state is 'defending':
        # Do things for this state
        print("Pretty strong for a short stack!, ah...")
        enemy_spotted -= 1
        enemy_weak -= 1

        # Check for change state
        if enemy_weak < 5:
            current_state = 'attacking'
        if enemy_spotted < 3:
            current_state = 'idle'
    # check for broken ... :(
    else:
        print("AH! BROKEN .... how did you get here?")
        die() # not a real function - just breaks things! :)

    if tired > 20:
        alive = False
        
    # Check for end of game time
    if game_time > max_limit:
        running = False

print('-- The End --')
