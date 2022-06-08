import React, { Fragment } from "react";
import { useParams } from "react-router-dom";

const ProductDetails : React.FC = () =>{
    const params = useParams();
    return (
        <Fragment>
            <h2>Product Details Page.</h2>
            <h4>Praments From URL is {params.id}</h4>
        </Fragment>
    );
}

export default ProductDetails;