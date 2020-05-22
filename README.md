# Welcome to the Britehouse Automotive Interview Test

* Fork this repo to your profile
* Create a branch with the prefix 'test/' and your name
* Start the API with Visual Studio, it should open on http://localhost:4201
* Start the frontend with command line, it should open on http://localhost:4200
* When you are done, please create a pull request for us to review

## API (C#)
* Refactor the Hero class to implement an interface of IHero.
* The `evolve` method on the class should increment all stats of the hero with a multiple of half the original stat value.
* The `post` method should read an `action` parameter which defaults to `none`
if the action is evolve it should evolve the hero and return the hero with its new stats.

## Front-end
### Angular
* create new service called 'api'
* add 1 method to service to get the contacts from the api located at 'http://localhost:4201/heroes'
* create new component named 'list'
* in the component, add the api service and get the list of contacts.
* display the list on the frontend.
* Columns: name, power, stat(strength), stat(intelligence), stat(stamina)
* next to each hero should be an `evolve` button.
* when the button is clicked, it should post the hero name and action to the relevant endpoint
* display the updated stats above the table "`Hero` updated with `Stats`", replacing the name and the stats

### CSS
* There should be a heading (h2) with the title 'Tour of Heroes'.
* Add a class called `heading` to the h2 tag
* center the heading
* set the color to `blue`
* create 4 color related classes with different font weights and colors and backgrounds.
* Add a random color class to the list of heroes
