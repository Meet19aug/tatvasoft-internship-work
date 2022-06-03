import React, { Fragment } from 'react';
import './App.css';
import { ClassBasedCounter } from './Components/ClassBasedCounter';
import Counter from './Components/Counter';
import CustomButton from "./Components/CustomButton";
import CustomInput from './Components/CustomInput';
import { NewComponent } from './Components/NewComponent';
import { Person } from './Components/Person';
import UseMemoComponents from './Components/UseMemoComponents';
import User from './Components/User';
import { UserWrapper } from './Context/User';

function App() {
  const handleButtonCLick = (label:String)=>{
    console.log(label); 
  }
  const handleChangeEvent = (event: React.ChangeEvent<HTMLInputElement>)=>{
    console.log(event.target.value);
  }
  return (
    <Fragment>
      <UserWrapper>
      {/* <CustomButton label="Click Here" handleClickEvent={handleButtonCLick} style={{background: "blue", color: "red", marginRight: "50px"}}/>
      <CustomButton label="Click Here Again" handleClickEvent={handleButtonCLick} style={{background: "red", color: "blue"}}/>
      <CustomInput value="PreDefined String" handleChange={handleChangeEvent}/> */}
      {/* <Counter/> */}
      {/* <ClassBasedCounter/> */}
      {/* <User/> */}
      <Person firstName='Meet' lastName='Patel'/>
      <NewComponent/>
      <UseMemoComponents/>
      </UserWrapper>
    </Fragment>
  );
}

export default App;
