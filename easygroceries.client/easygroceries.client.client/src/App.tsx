//import { useEffect, useState } from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.css';
import { Products } from './app/components/products/Products';
import { Header } from './app/components/Header/Header';


function App() {
    return (
        <BrowserRouter>
        <Header />
        <Products />
        </BrowserRouter>
    )
}


export default App;