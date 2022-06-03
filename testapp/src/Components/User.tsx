import React, {Fragment, useState} from "react";
interface Person{
    firstName:String,
    lastName:String,
}
const User: React.FC = ()=>{
    const [userDetails, setUserDetails] = useState<Person>({
        firstName: "TestFName",
        lastName: "TestLName",
    })
    const showUserDetailsOnClick = ()=>{
        setUserDetails({
            firstName: "Meet",
            lastName: "Patel",
        })
    }
    return(
        <Fragment>
            <h2>{userDetails.firstName} {userDetails.lastName}</h2>
            <button onClick={showUserDetailsOnClick}>Show User Details</button>
        </Fragment>
    );
}
export default User;