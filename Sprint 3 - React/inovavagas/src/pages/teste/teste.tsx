import React from 'react';
import Input from '../../components/input/index';
import Search from '../../components/searchBar/index';
import CardButton from '../../components/cardButton/index';
import imgUserRed from '../../assets/images/user_Vermelho.png';
import imgPredioRed from '../../assets/images/predio_Vermelho.png';
import './style.css';
import {Link} from 'react-router-dom';

function Teste() {
  return (
    <div className='align'>
      <Input name='email' classCSS='input-label' label='Endereço de Email' type='email'/>
      <Input name='password' classCSS='input-password' label='Senha' type='password'/>
      <Input name='text' classCSS='input-placeholder' placeholder='Text' type='text'/>
      <Input name='select' classCSS='input-select' placeholder='Frutas' type='select'/>
      <Search/>
      
      <Link to='/'><CardButton title='Ver Alunos' img={imgUserRed}/></Link>
      
      <Link to='/login'><CardButton title='Ver Empresa' img={imgPredioRed} description='vai la faz com gosto as coisa e pa e talz ai vai dar certo sabe?'/></Link>
      
    </div>
  );
}

export default Teste;