import React, { useContext } from "react";
import { userContext } from "../Context/User";

type PersonProps = {
  firstName: "Keval" | "Meet";
  lastName: string;
};

export const Person: React.FC<PersonProps> = ({ firstName, lastName }) => {
  const UserData = useContext(userContext);
  console.log(UserData);
  return (
    <>
      <h1>Person Component</h1>
      hello {firstName} {lastName}
      <p>User Name : {UserData.user.name}</p>
      <p>User Age : {UserData.user.age}</p>
    </>
  );
};
