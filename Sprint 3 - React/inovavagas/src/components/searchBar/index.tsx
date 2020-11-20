import React, { InputHTMLAttributes } from 'react';
//import InputGroup from 'react-bootstrap/InputGroup';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import FormControl from 'react-bootstrap/FormControl';
import './style.css';
import 'bootstrap/dist/css/bootstrap.min.css';

interface SearchProps extends InputHTMLAttributes<HTMLInputElement> {
    event?: any;
}

const Search: React.FC<SearchProps> = ({ event, ...rest }) => {
    return (
        <div className="search">
            <FormControl type='text' placeholder='Pesquisar...' onClick={event} bsPrefix='input'></FormControl>
        </div>
    );
}

export default Search;