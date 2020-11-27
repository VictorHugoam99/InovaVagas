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
        <div className="buttonFull">
            <input  className='botao-entrar'value={name} size={tamanho} type='submit' onClick={onClick}{...rest}/>
        </div>
    );
}

export default ButtonFull;