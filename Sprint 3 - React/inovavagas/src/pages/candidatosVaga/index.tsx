import React from 'react';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';


function CandidatosVaga(){
    return (
        <div className="visualizarVaga">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />

            <Footer/>
        </div>
    );
}

export default CandidatosVaga;