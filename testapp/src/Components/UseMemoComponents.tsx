import React, { Fragment, useMemo, useState } from "react";

const UseMemoComponents = ()=>{
    const [counterOne, setCounterOne] =useState<number>(0);
    const [counterTwo, setCounterTwo] =useState<number>(0);
    // const isEven = ():boolean=>{
    //     var i:number=0;
    //     while(i<200000000)
    //         i++;
    //     return counterOne%2===0;
    // }
    const isEven = useMemo(() => {
        var i:number=0;
        while(i<200000000)
            i++;
        return counterOne%2===0;
    }, [counterOne])
    return (
        <Fragment>
            <div>
                <button onClick={() => setCounterOne(counterOne+1)}>Counter 1 is {counterOne}</button>
                {/* <span>{isEven() ? "Even" : "Odd"}</span> */}
                <span>{isEven ? "Even" : "Odd"}</span>
            </div>
            <div>
                <button onClick={() => setCounterTwo(counterTwo+1)}>Counter 2 is {counterTwo}</button>
            </div>
        </Fragment>
    );
}

export default UseMemoComponents;