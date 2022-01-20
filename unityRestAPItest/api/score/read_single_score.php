<?php
//Headers
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');

include_once '../../config/Database.php';
include_once '../../models/score.php';

//Instantiate DB & connect
$database = new Database();
$db = $database->connect();

//Instantiate score object
$score = new Score($db);

//Get userID from URL
$score->userID = isset($_GET['userID']) ? $_GET['userID'] : die();

//Get score
$score->read_single_score();

//Create array
$score_arr = array(
    'userID' => $score->userID,
    'scoreID' => $score->scoreID,
    'score' => $score->score,
);

//Make JSON
print_r(json_encode($score_arr));

?>