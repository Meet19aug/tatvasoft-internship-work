import React, { Fragment } from 'react'
type CustomInputProps = {
    value : string,
    handleChange : (event: React.ChangeEvent<HTMLInputElement>) => void,
}
const CustomInput: React.FC<CustomInputProps> = (props) => {
  return (
    <Fragment>
        <input type="text" value={props.value} onChange={(event) =>{props.handleChange(event)}}/>
    </Fragment>
  )
}

export default CustomInput;