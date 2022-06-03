import React from "react";
type CustomButtonProps = {
    label: String,
    style: React.CSSProperties,
    handleClickEvent : (label: String)=>void
}

const CustomButton : React.FC<CustomButtonProps> = (props)=>{
    return(
        <>
        <button type="button" onClick={() => props.handleClickEvent(props.label)} style={props.style}>{props.label} </button>
        </>
    )
}
export default CustomButton;