import { useState, useEffect } from 'react';
import { Product } from '../../app/models/product';
import ProductList from './ProductList';
import agent from '../../app/api/agent';
import LoadingComponent from '../../app/layout/LoadingComponent';

export default function Catalog() {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        fetch('https://localhost:7089/products')
        .then(response => response.json())
        .then(data => setProducts(data.products));
    }, [])
  
    return (
        <>
            <ProductList products={products} />
        </>
    )
}