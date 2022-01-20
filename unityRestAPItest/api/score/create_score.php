<?php
//Headers
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');
header('Access-Control-Allow-Methods: POST');
header('Access-Control-Allow-Headers: Access-Control-Allow-Headers,Content-Type,Access-Control-Allow-Methods,Authorization,X-Requested-With');

include_once '../../config/Database.php';
include_once '../../models/score.php';

//Instantiate DB & connect
$database = new Database();
$db = $database->connect();

//Instantiate score object
$score = new Score($db);

//Get raw posted data
$data = json_decode(file_get_contents("php://input"));

//Set scoreID
$score->userID = $data->userID;
$score->score = $data->score;

//Create score
if($score->create_score()){
    echo json_encode(
        array('message' => 'Score Created')
    );
}else{
    echo json_encode(
        array('message' => 'Score Not Created')
    );
}