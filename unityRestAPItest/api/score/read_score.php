<?php
//Headers
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');

include_once '../../config/Database.php';
include_once '../../models/score.php';

//Instantiate DB & connect
$database = new Database();
$db = $database->connect();

//Instantiate score
$score = new Score($db);
$result = $score->read_score();

//Get row count
$num = $result->rowCount();

//Check if any score
if($num > 0){
    //score array
    $score_arr = array();
    $score_arr['data'] = array();

    while($row = $result->fetch(PDO::FETCH_ASSOC)){
        extract($row);

        $score_item = array(
            'userID' => $userID,
            'scoreID' => $scoreID,
            'score' => $score
        );

        //Push to "data"
        array_push($score_arr['data'], $score_item);
    }
    //Turn to JSON and output
    echo json_encode($score_arr);

}else{
//No scores
echo json_encode(
    array('message' => 'No scores Found')
);
}


?>