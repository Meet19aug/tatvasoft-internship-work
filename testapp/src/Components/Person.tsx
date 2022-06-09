import React, { useContext } from "react";
import { userContext } from "../Context/User";

type PersonProps = {
  firstName: "Keval" | "Meet";
  lastName: string;
};

export const Person: React.FC<PersonProps> = ({ firstName, lastName }) => {
  const UserData = useContext(userContext);
  console.log(UserData);

  //Without Axios
  // const GetData = async ()=>{
  //   try {
  //     const response = await fetch("http://apicalls/api",{
  //     method:"POST",
  //     headers:{
  //       "Content-type": "application/json",
  //     },
  //     body:{}
  //     });
  //   } catch (error) {
  //    console.log("Error Occured: "); 
  //   }
  // }
  //With Axios with promise
  // const GetData = ()=>{
  //   axios.get("http://apicalls/asd/dsa",data, {
  //       headers:{

  //       }
  //   }).then((re)=>console.log(re));
  // }

  return (
    <>
      <h1>Person Component</h1>
      hello {firstName} {lastName}
      <p>User Name : {UserData.user.name}</p>
      <p>User Age : {UserData.user.age}</p>
    </>
  );
};
