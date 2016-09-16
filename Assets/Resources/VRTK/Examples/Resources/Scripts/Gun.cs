namespace VRTK.Examples
{
    using UnityEngine;

    public class Gun : VRTK_InteractableObject
    {
        private GameObject bullet;
        public float bulletSpeed = 1000f;
        private float bulletLife = 5f;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
           // FireBullet();
        }

        protected override void Start()
        {
            base.Start();
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);

            GetComponentInParent<VRTK_ControllerEvents>().AliasUIClickOn += new ControllerInteractionEventHandler(FireBullet);
        }

        private void DoGrabOn(object sender, ControllerInteractionEventArgs e) {
            print("HI THERE");
        }


        private void FireBullet(object sender, ControllerInteractionEventArgs e) {
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
    }
}