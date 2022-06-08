import React, { Fragment } from 'react'
import { Link, Routes, Route } from 'react-router-dom'
import AboutUs from './Components/AboutUs'
import ContactUs from './Components/ContactUs'
import Home from './Components/Home'
import PageNotFound from './Components/PageNotFound'
import ProductDetails from './Components/ProductDetails'
import Products from './Components/Products'
import { RouteConstats } from './Constants/RouteConstant'

function RouteConfig() {
  return (
    <Fragment>
       <Routes>
           <Route path="*" element={<PageNotFound/>} />
           <Route path="/" element={<Home/>}/>
           <Route path={RouteConstats.ABOUT_US} element={<AboutUs/>} />
           <Route path={RouteConstats.CONTACT_US} element={<ContactUs/>} />
           <Route path={RouteConstats.PRODUCTS} element={<Products/>}/>
           <Route path={RouteConstats.PRODUCT_DETAILS} element={<ProductDetails/>}/>
       </Routes>
    </Fragment>
  )
}

export default RouteConfig