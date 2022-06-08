import React, { Fragment } from "react";
import { useNavigate } from "react-router-dom";

const Products :React.FC = () =>{
    const navigateTo = useNavigate();
    return (
        <Fragment>
            <h2>Product Page.</h2>
            <button onClick={()=> navigateTo("product/1")}>Product list</button>
        </Fragment>
    );

}
export default Products;