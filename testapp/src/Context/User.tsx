import React, { createContext, useState } from "react";

type UserType = {
    name:string,
    age:number,
}

type UserContextType = {
    user: UserType,
    setUserData : (userData: UserType) => void;
};

const InitialValue: UserContextType = {
    user:{
        name:"",
        age:0,
    },
    setUserData:()=>{}, 
}

export const userContext = createContext(InitialValue);

export const UserWrapper: React.FC<React.PropsWithChildren<{}>> = ({children,}) => {
     const [user, setUser] = useState<UserType>({
         name:"",
         age:0,
     });

     const setUserData = (userData: UserType) =>{
        setUser(userData);
     };

     const value = {
        user,
        setUserData,
     }
    return <userContext.Provider value={value} >{children}</userContext.Provider>
};

