import React, { useContext, useMemo, useState } from "react";
import { userContext } from "../Context/User";

export const NewComponent = () => {
  const [counterOne, setCounterOne] = useState<number>(0);
  const [counterTwo, setCounterTwo] = useState<number>(0);

  const isEven = useMemo(() => {
    let i = 0;
    while (i < 2000000000) i++;
    return counterOne % 2 === 0;
  }, [counterOne]);

  const UserContextData = useContext(userContext);

  return (
    <>
      <div>
        <button onClick={() => setCounterOne(counterOne + 1)}>
          CounterOne - {counterOne}
        </button>
        <span>{isEven ? "Even" : "Odd"}</span>
      </div>
      <div>
        <button onClick={() => setCounterTwo(counterTwo + 1)}>
          CounterTwo - {counterTwo}
        </button>
      </div>
      <h5>New Component</h5>
      <button
        onClick={() => UserContextData.setUserData({ name: "Mento", age: 20 })}
      >
        updat value
      </button>
    </>
  );
};
