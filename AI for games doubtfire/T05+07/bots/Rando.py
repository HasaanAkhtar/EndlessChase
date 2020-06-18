from random import choice


class Rando(object):

    def update(self, gameinfo):

        # only send one fleet at a time

        # check if we should attack
        if gameinfo.my_planets and gameinfo.not_my_planets:
            if gameinfo.my_fleets:
                return
            # select random target and destination

            src = max(gameinfo.my_planets.values(), key=lambda p: p.num_ships)
            # Find a target planet with the minimum number of ships.
            dest = min(gameinfo.not_my_planets.values(), key=lambda p: p.num_ships)

            # launch new fleet if there's enough ships
            if src.num_ships > 10:
                gameinfo.planet_order(src, dest, int(src.num_ships * 0.75))
