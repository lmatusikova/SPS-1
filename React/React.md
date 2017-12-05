React
========

 - JavaScript framework, one from big triple ([Angular](https://angularjs.org/), [Vue](https://vuejs.org/))
 - first deployed on 2011, [open-sourced](https://github.com/facebook/react) in 2013
 - current version 16 (Sep 2017) - [licensing issues](https://thenextweb.com/dd/2017/09/25/facebook-re-licenses-react-mit-license-developer-backlash/)

----------

## Virtual DOM

Classical JavaScript:

![enter image description here](https://docs.google.com/drawings/d/1sLx_t031l82kP3Gq7547C1sGcQWgIxViPYfxCo-ZJto/pub?w=340&h=205)

React (also Vue):

![enter image description here](https://docs.google.com/drawings/d/11ugBTwDkqn6p2n5Fkps1p3Elp8ZToIRzXzvM4LJMYaU/pub?w=543&h=229)

As updating of [DOM](https://www.w3schools.com/js/js_htmldom.asp) is expensive, React uses *Virtual DOM*, which is maintained purely by React itself and reflects changes made by user. Real DOM is updated in background and only as little as possible.

----------

ES6, Babel, JSX etc.
----------

### ES6 (ECMAScript6, ES2015)
- standard for JavaScript
- supported in all major current browsers (but not in every older)
- [some features](http://blog.teamtreehouse.com/get-started-ecmascript-6)

### Babel
- transpiler 
- "translates" ES6 to ES5 so that every browser can understand the code

### JSX
- language - combination of HTML and JavaScript
- we could (of course) do without it, but it makes coding things simpler 

----------
Components, state, props
----------

### Components

Components are basic building blocks of React applications.

HelloWorld component:

    class Hello extends React.Component {
      render() {
        return <div>Hello World!</div>;
      }
    }

Inside HTML document:

    <body>
	    ...
	    <Hello />
	    ...
	</body>

Result:

    Hello World!


### Properties

*props* (short for properties) are component's configuration

- they are received from above and immutable
- component cannot change its props
- component is responsible for putting together the props of its child components

Example: https://jsfiddle.net/reactjs/69z2wepo/

### State

The *state* starts with a default value when a component mounts and then is changed in time (mostly because of user events) - every time the state is changed, component automatically re-renders. 

- serializable representation of one point in time - a snapshot
- component manages its own state internally
- does nothing with the state of its children - state is private

Example: https://jsfiddle.net/f3756vws/1/

- state changing is asynchronous - be careful when setting value based on previous value ([read more](http://lucybain.com/blog/2016/react-state-vs-pros/))

### Component lifecycle

#### Mounting
These methods are called when an instance of a component is being created and inserted into the DOM:

     - constructor() 
     - componentWillMount() 
     - render()
     - componentDidMount()

#### Updating
An update can be caused by changes to props or state. These methods are called when a component is being re-rendered:

     - componentWillReceiveProps() 
     - shouldComponentUpdate()
     - componentWillUpdate() 
     - render() 
     - componentDidUpdate()

#### Unmounting
This method is called when a component is being removed from the DOM:

    componentWillUnmount()
    

--------
## What do we need

1. IDE
- [Visual Studio Code](https://code.visualstudio.com/)
- online editors:
  * [Plunker](https://plnkr.co/)
  * [Stackblitz](https://stackblitz.com/)
2. [Node.js](https://nodejs.org/en/download/)
3. ([a boilerplate](https://www.andrewhfarmer.com/starter-project/))
4. ([Typescript](https://www.typescriptlang.org/))

--------
## Example

Handling a form: https://jsfiddle.net/or42y07L/

--------

Exercises
=====

### Task 1
Change prearranged code in a way, that after a click on a square, the square will display letter 'X' inside.

https://jsfiddle.net/cw8p4fof/

### Task 2
Change the code in task 1 to get letters 'X', 'O' in turns. (Also change status e.g. whom's move)
Hint on how to manage state changes between parent and child components: https://ourcodeworld.com/articles/read/409/how-to-update-parent-state-from-child-component-in-react 

### Task 3
Change the code in task 2 to find out the end of game e.g. 3 letters 'X' or 'O' are on one line.


--------
## Appendix: Testing web applications

When curious about testing JavaScript, components etc., I strongly recommend reading [this article](https://medium.com/powtoon-engineering/a-complete-guide-to-testing-javascript-in-2017-a217b4cd5a2a).

## Links

 - http://blog.reverberate.org/2014/02/react-demystified.html 
 - http://reactkungfu.com/2015/10/the-difference-between-virtual-dom-and-dom/
 - https://www.fullstackreact.com/30-days-of-react/day-2/
 - http://blog.teamtreehouse.com/get-started-ecmascript-6
 - http://es6-features.org/
 - https://reactjs.org/docs/react-component.html
 - https://github.com/uberVU/react-guide/blob/master/props-vs-state.md
 - http://lucybain.com/blog/2016/react-state-vs-pros/
