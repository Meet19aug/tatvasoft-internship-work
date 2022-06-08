import React, { Fragment } from 'react'
import { useNavigate } from 'react-router-dom'

const AboutUs : React.FC = ()=>{
    const navigateTo = useNavigate(); 
    return (
        <Fragment>
            <h2>About Us Page.</h2>
            <button onClick={() => navigateTo("/contactus")}>GOTO Contact Us Page</button>
        </Fragment>
      )
}


export default AboutUs