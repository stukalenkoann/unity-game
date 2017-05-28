  public float doorOpenAngle = 90.0f;
  public float doorCloseAngle = 0.0f;
  public float doorAnimSpeed = 2.0f;
  private Quaternion doorOpen = Quaternion.identity;
  private Quaternion doorClose = Quaternion.identity;
  private Transform playerTrans = null;
  public bool doorStatus = false; 
  private bool doorGo = false; 
  void Start() {
   doorStatus = false;
   doorOpen = Quaternion.Euler (0, doorOpenAngle, 0);
   doorClose = Quaternion.Euler (0, doorCloseAngle, 0);
   playerTrans = GameObject.Find ("Player").transform;
  }
  void Update() {
   if (Input.GetKeyDown(KeyCode.F) && !doorGo) {
    if (Vector3.Distance(playerTrans.position, this.transform.position) < 5f) {
     if (doorStatus) { 
      StartCoroutine(this.moveDoor(doorClose));
     } else { 
      StartCoroutine(this.moveDoor(doorOpen));
     }
    }
   }
  }
  public IEnumerator moveDoor(Quaternion dest) {
   doorGo = true;
   while (Quaternion.Angle(transform.localRotation, dest) > 4.0f) {
    transform.localRotation = Quaternion.Slerp(transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
    yield return null;
   }
   doorStatus = !doorStatus;
   doorGo = false;
   yield return null;
  }