<?php
//Headers
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');

include_once '../../config/Database.php';
include_once '../../models/user.php';

//Instantiate DB & connect
$database = new Database();
$db = $database->connect();

//Instantiate user object
$user = new User($db);

//Get username and password from URL
$user->username = isset($_GET['username']) ? $_GET['username']: die();
$user->password = isset($_GET['password']) ? $_GET['password']: die();

//Get user
$user->read_single_user();

//Create array
$user_arr = array(
    'userID' => $user->userID,
    'username' => $user->username,
    'password' => $user->password,
);

//Make JSON
print_r(json_encode($user_arr));

?>