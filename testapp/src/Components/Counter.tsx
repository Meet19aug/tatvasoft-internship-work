import React, {useState, useEffect }from "react";

const Counter : React.FC = ()=>{
    const [counter, setCounter] = useState(0);
    useEffect(()=>{
        console.log("FirstLoad!!");
    },[])
    useEffect(() => {
      console.log("counter changed");
    }, [counter])
    
    const incrementCounter = ()=>{
        setCounter(counter+1);
    }
    const decrementCounter = ()=>{
        setCounter(counter-1);
    }
    return(
    <>
    <h1>{counter}</h1>
        <button onClick={incrementCounter}>Increment</button>
        <button onClick={decrementCounter}>Decrement</button>
    </>
    );
}   

export default Counter;