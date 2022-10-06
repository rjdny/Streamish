import React, { useState } from "react";
import { addVideo } from "../modules/videoManager";

//Video Form Element
const VideoForm = ({getVideos}) => {
    const [errMsg, setErrMsg] = useState('')

    //Submit the new video info to database
    const Submit = () =>{
        let Title = document.querySelector('#nvTitle')
        let Description = document.querySelector('#nvDesc')
        let Url = document.querySelector('#nvUrl')

        if(!Title.value){
            setErrMsg('Please enter a valid Title.')
        }
        else if(!Url.value){
            setErrMsg('Please enter a valid Youtube URL.')
        }
        else{
        //Add the info to the database, clear the text boxes, and update the vido list to include the new one.
        addVideo({title:Title.value, description:Description.value, url: Url.value}).then(() => {
            Title.value = '';
            Description.value = '';
            Url.value = '';
            setErrMsg('')
        }).then(() => getVideos())
        }
    }

    //return a div with all the options for customizing a video before adding it to the database, and the button to do so.
    return (<div style={{zIndex:'999999',position:'absolute', marginLeft:"10px",border:"1px solid grey",borderRadius:"10", width:"230px"}}>
        <h3>Add a video</h3>
        <label>Title: <input id="nvTitle" type={"text"}></input></label>
        <label>Description: <input id="nvDesc" type={"text"}></input></label>
        <label>URL: <input id="nvUrl" type={"text"}></input></label>
        <div><label style={{color:'red'}}>{errMsg}</label></div>
        <button onClick={() => {Submit()}} style={{height:"35px", margin:"10px", borderRadius:"20px"}}>Add Video</button>
    </div>)
}


export default VideoForm;


