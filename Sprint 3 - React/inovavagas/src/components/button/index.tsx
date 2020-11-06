import React from 'react';
import './style.css';
import Button from 'react-bootstrap/Button';

interface ButtonProps {
    name: string;
    tamanho?: any;
    screenSize?: string;
    onClick?: any;
    // variante?: string;
}

const ButtonFull: React.FC<ButtonProps> = ({ name, tamanho, screenSize, onClick,...rest }) => {
    return (
        <input value={name} size={tamanho} type='submit' onClick={onClick}{...rest}/>
    );
}

export default ButtonFull;