import React, {Component, Fragment} from "react";
type ClassBasedCounterType={
    counter:number,
}
export class ClassBasedCounter extends Component<{}, ClassBasedCounterType>{
    state={
        counter: 0,
    };
    incrementCounter = ()=>{
        this.setState((prevState) => ({counter : prevState.counter+1}))
    }
    decrementCounter = ()=>{
        this.setState((prevState) => ({counter : prevState.counter-1}))
    }
    render(){
        return(
            <Fragment>
                <h1>{this.state.counter}</h1>
                    <button onClick={this.incrementCounter}>Increment</button>
                    <button onClick={this.decrementCounter}>Decrement</button>
            </Fragment>
        );
    }

}