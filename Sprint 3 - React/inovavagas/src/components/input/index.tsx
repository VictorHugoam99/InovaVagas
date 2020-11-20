import React, { InputHTMLAttributes } from 'react';
//import InputGroup from 'react-bootstrap/InputGroup';
import Form from 'react-bootstrap/Form';
import FormGroup from 'react-bootstrap/FormGroup';
import FormText from 'react-bootstrap/FormText';
import FormControl from 'react-bootstrap/FormControl';
import FormLabel from 'react-bootstrap/FormLabel';
import Dropdown from 'react-bootstrap/Dropdown';
import './style.css';
// import 'bootstrap/dist/css/bootstrap.min.css';
import FormCheckLabel from 'react-bootstrap/esm/FormCheckLabel';

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
    name: string;
    label?: string;
    placeholder?: string;
    type: string;
}

// Como Usar:
// Existem quatro variações do input. Uma com texto encima do input ,outra com o texto dentro do input e um select

// Para usar a primeira versão, é preciso colocar na chamada do componente, por exemplo: name='email' classCSS='input-label' label='Endereço de Email' type='email'

// Para usar a segunda versão é necessário colocar na chamada, por exemplo: name='text' classCSS='input-placeholder' placeholder='Text' type='text'

// Para usar a terceira versao é necessario informar, por exemplo: name='select' classCSS='input-select' placeholder='Frutas' type='select'

// Para usar a quarta versao é necessario informar, por exemplo: name='password' classCSS='input-password' label='senha' type='password'

// Entendendo os props:
// name => usado para referenciar o label com o input
// label => usado para mostrar um texto encima do input
// placeholder => usado para mostrar um texto dentro do input
// type => usado para especificar o tipo do input
// classCSS: usado para estilizar as duas versões de input (só deve ser escrito "input-label", "input-placeholder" ou input-select nesse campo)
// description => usado para inserir um texto encima descrevendo o input

const Input: React.FC<InputProps> = ({ name, label, type, placeholder, ...rest }) => {
    return (
        <div className='FormGroup'>
            {/* <FormText>{description}</FormText>
                <FormControl type={type} id={name} placeholder={placeholder} bsPrefix={classCSS} minLength={8} maxLength={16}/> */}
            <p>{label}</p>
            <input type={type} id={name} placeholder={placeholder} className='input-placeholder'{...rest} />
        </div>
    );
}
    
export default Input;