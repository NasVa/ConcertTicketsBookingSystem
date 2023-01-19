import React from 'react' 
import Form from 'react-bootstrap/Form';

export default function Search({ searchValue, setSearchValue}){

    return(
        <Form.Control type="search" placeholder="search..." name = "search" onChange={ (event) => {setSearchValue(event.target.value)}}/>
    )
}