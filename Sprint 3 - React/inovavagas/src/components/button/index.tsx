import React from 'react';
import './style.css';
import Button from 'react-bootstrap/Button';

interface ButtonProps{
    name: string;
    tamanho: any;
    screenSize?: string;
    variante?: string;
}

const ButtonFull:React.FC<ButtonProps> = ({name, tamanho, screenSize, variante, ...rest}) => {
    if(variante === 'outline-danger'){
        return(
            <Button variant="outline-danger" size={tamanho}{...rest}>
                {name}
            </Button>
        );
    }    
    else{
        return(
            <Button variant="danger" className="btn-danger" size={tamanho}{...rest}>
                {name}
            </Button>
        );
    }
}

export default ButtonFull;